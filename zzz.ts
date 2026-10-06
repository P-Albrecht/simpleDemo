import React from 'react';

type BadgeProps = {
  label?: string;
  icon?: React.ReactNode;
  color?: string;
  size?: string;
  disablePulse?: boolean;
};

export function Badge({
  label,
  icon,
  color = 'primary',
  size = 'xs',
  disablePulse = false,
}: BadgeProps) {
  return (
    <div
      className={`inline-flex items-center gap-2 px-5 py-2 rounded-full border border-${color}/25 bg-${color}/[0.08] backdrop-blur-md`}
    >
      <span className={`text-${color} text-${size}`}>{icon}</span>
      <span className={`text-${color} text-${size} font-mono tracking-wide`}>
        {label}
      </span>
      {!disablePulse && (
        <span className="relative flex h-2 w-2">
          <span
            className={`animate-pulse inline-flex rounded-full h-2 w-2 bg-${color}`}
          ></span>
        </span>
      )}
    </div>
  );
}

type SimpleBadgeProps = {
  children: React.ReactNode;
};

export function SimpleBadge({ children }: SimpleBadgeProps) {
  return (
    <span className="self-start mt-4 text-xs font-mono text-primary/70 border border-primary/20 rounded-full px-3 py-1">
      {children}
    </span>
  );
}
